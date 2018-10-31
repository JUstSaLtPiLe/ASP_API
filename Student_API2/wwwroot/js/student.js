function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'rollNumber': $('#add-rollNumber').val(),
        'avatar': $('#add-avatar').val(),
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: 'api/student',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            history.back();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: '/Student/Delete/' + id,
        type: 'DELETE',
        success: function (result) {
            $("#student-" + id).remove();
        },
        error: function () {
            alert("error");
        }
    });
}

function editItem(id) {
    $('#edit-form').css({ 'display': 'block' });
    $.ajax({
        type: 'GET',
        url: '/Student/GetById/' + id,
        success: function (data) {
            $('#edit-id').val(data.id);
            $('#edit-name').val(data.name);
            $('#edit-rollNumber').val(data.rollNumber);
            $('#edit-avatar').val(data.avatar);
        },
        error: function () {
            alert("error");
        }
    });
}

$('#edit-form').on('submit', function () {
    id = $('#edit-id').val();
    const studentChanges = {
        'name': $('#edit-name').val(),
        'rollNumber': $('#edit-rollNumber').val(),
        'avatar': $('#edit-avatar').val()
    };
    $.ajax({
        url: '/Student/Update/' + id,
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(studentChanges),
        success: function (res){
            $('#edit-form').css({ 'display': 'none' });
            $("#student-" + id).html(
                '<td>' + res.name + '</td>' +
                '<td>' + res.rollNumber + '</td>' +
                '<td>' + res.avatar + '</td>' +
                '<td><button onclick="editItem(' + res.id + ')">Edit</button></td>' +
                '<td><button onclick="deleteItem(' + res.id + ')">Delete</button></td>'
            );
        },
        error: function (){
            alert("error");
        }
    });
});