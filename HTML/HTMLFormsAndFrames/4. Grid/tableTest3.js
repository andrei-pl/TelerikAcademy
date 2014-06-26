// JavaScript Document
// Thank you VERY much to Ben Nadel for this on his blog
// posted at
//http://www.bennadel.com/blog/1504-Ask-Ben-Parsing-CSV-Strings-With-Javascript-Exec-Regular-Expression-Command.htm
if (window.XMLHttpRequest) {
    //for firefox, opera and safari browswers
    var txtFile = new XMLHttpRequest();
}
if (typeof XMLHttpRequest == "undefined")
    XMLHttpRequest = function () {
        try { return new ActiveXObject("Msxml2.XMLHTTP.6.0"); }
        catch (e) { }
        try { return new ActiveXObject("Msxml2.XMLHTTP.3.0"); }
        catch (e) { }
        try { return new ActiveXObject("Msxml2.XMLHTTP"); }
        catch (e) { }
        //Microsoft.XMLHTTP points to Msxml2.XMLHTTP.3.0 and is redundant
        throw new Error("This browser does not support XMLHttpRequest.");
    };
txtFile.open("GET", "bilgi.txt");
txtFile.send(false);
var allText = txtFile.responseText;
function clickyHere() {
    //var tar = document.getElementById('finalTable');
    var info = txtFile.responseText;
    var infoArray = [];
    infoArray = info.split(/,|,+\s|\s+,\n|\r/);
    var tableCount = info.split(/,|\$/g).length;
    var rowCount = info.split(/\r|[\r]/g).length;
    var endLine = info.split(/\$/g).length;
    var columnTry = tableCount / endLine;
    var count;
    count = 0;
    for (i = 0; i < infoArray.length; i++) {
        x = infoArray[i];
        document.write(x + "&nbsp;");
        if (count != columnTry) {
            count++;
            //document.write("<br />");
        }
        if (count >= columnTry) {
            count = 0;
        }
    }
}