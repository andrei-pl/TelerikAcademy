namespace MongoChatClient
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    using MongoChat.Models;
    using MongoChat.Data;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private Thread updatePostsThread;
        MongoChatModule mongoChatModule;

        public ChatWindow(UserSession user)
        {
            this.InitializeComponent();
            this.User = user;

        }

        private UserSession User { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeMongoChatModule();
            this.ShowAllPostsAsync(this.GetDateTimeRange());
            this.txtMessage.Focus();
            this.UpdatePostsEachMsAsync();
        }

        private void InitializeMongoChatModule()
        {
            var mongoDbContext = new MongoDbContext();
            this.mongoChatModule = new MongoChatModule(mongoDbContext);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            base.OnClosed(e);
            this.updatePostsThread.Abort();
            App.Current.Shutdown();
        }

        private Tuple<DateTime, DateTime> GetDateTimeRange()
        {
            return Tuple.Create(DateTime.MinValue, DateTime.MaxValue);
        }

        private async void ShowAllPostsAsync(Tuple<DateTime, DateTime> dateTimeRanges)
        {
            var postsAsString = await this.GetPostsAsString(dateTimeRanges);
            this.txtChatMessages.Text = postsAsString.ToString();
            this.txtChatMessages.ScrollToEnd();
        }

        private Task<string> GetPostsAsString(Tuple<DateTime, DateTime> dateTimeRange)
        {
            return Task.Run(() =>
            {
                return this.mongoChatModule.GenerateAllPostsAsString(dateTimeRange.Item1, dateTimeRange.Item2).ToString();
            });
        }

        private async void UpdatePostsEachMsAsync(int refreshMs = 500)
        {
            this.updatePostsThread = new Thread(async () =>
            {
                while (true)
                {
                    this.txtChatMessages.Dispatcher.BeginInvoke((Action)(async () => this.UpdatePosts()));
                    Thread.Sleep(refreshMs);
                }
            });

            this.updatePostsThread.Start();
        }

        private async void UpdatePosts()
        {
            var haveNewPosts = await this.mongoChatModule.HaveNewPosts();
            if (!haveNewPosts)
            {
                return;
            }

            var newPostsAsString = await this.GetPostsAsString(this.GetDateTimeRange());
            this.txtChatMessages.Text = newPostsAsString;
            this.txtChatMessages.ScrollToEnd();
        }

        private void OnSend_Click(object sender, RoutedEventArgs e)
        {
            var postContent = this.txtMessage.Text;
            if (string.IsNullOrEmpty(postContent))
            {
                return;
            }

            var postModel = new Post()
            {
                Content = postContent,
                PostOn = DateTime.Now,
                PostedBy = this.User.Name
            };

            this.txtMessage.Text = string.Empty;
            this.mongoChatModule.AddPost(postModel);
            this.txtChatMessages.Text += (this.txtChatMessages.Text.Length > 0 ? Environment.NewLine : string.Empty) +
                                         this.mongoChatModule.GenerateOnePostAsString(postModel);
            this.txtChatMessages.ScrollToEnd();
        }
    }
}
