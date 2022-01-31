let StudentId = "";
let GroupId = "";

$(document).ready(function () {
    console.log("Student JS load");

    /*Удаление студента*/

    $('.delStudent').each(function () {
        $(this).on('click', function () {
            StudentId = $(this).parent().find('#student-id').val();
            $('#fDelStudent').parent().toggleClass("mOn");
            $('#fDelStudent').find('#question-hidden').val(StudentId);
            console.log(id);
        });
    });


    $('#cDelStudent').on('click', function () {
        $('#fDelStudent').parent().toggleClass("mOn");
        StudentId = "";
        $('#fDelStudent').find('#question-hidden').val(StudentId);
    });

    /*Удаление группы*/

    $('.delGroup').each(function () {
        $(this).on('click', function () {
            GroupId = $(this).parent().find('#group-id').val();
            $('#fDelGroup').parent().toggleClass("mOn");
            $('#fDelGroup').find('#question-hidden').val(GroupId);
            console.log(id);
        });
    });

    $('#cDelGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
        GroupId = "";
        $('#fDelGroup').find('#question-hidden').val(GroupId);
    });
});