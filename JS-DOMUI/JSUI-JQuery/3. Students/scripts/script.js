(
function () {
    var students = [{
        firstName: 'Peter',
        lastName: 'Ivanov',
        grade: 3
    }, {
        firstName: 'Milena',
        lastName: 'Grigorova',
        grade: 6
    }, {
        firstName: 'Gergana',
        lastName: 'Borisova',
        grade: 12
    }, {
        firstName: 'Boyko',
        lastName: 'Petrov',
        grade: 7
    }];

    var $table = $('<table>');
    var $thead = $('<thead>');
    var $tr = $('<tr>');
    $tr.append($('<th>').text('First name'));
    $tr.append($('<th>').text('Last name'));
    $tr.append($('<th>').text('Grade'));
    var $tbody = $('<tbody>');

    for (var i in students) { // students is in the testArray.js
        var $stInfo = $('<tr>');
        $stInfo.append($('<td>').text(students[i].firstName));
        $stInfo.append($('<td>').text(students[i].lastName));
        $stInfo.append($('<td>').text(students[i].grade));

        $stInfo.appendTo($tbody);
    }
    $tr.appendTo($thead);
    $thead.appendTo($table);
    $tbody.appendTo($table);
    $table.appendTo($('body'));

})();