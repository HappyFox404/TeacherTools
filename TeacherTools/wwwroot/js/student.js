let StudentId = "";

$(document).ready(function () {
    console.log("Student JS load");

    /*Удаление студента*/

    $('.delStudent').each(function () {
        console.log("123")
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

    $('#delGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
    });

    $('#cDelGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
    });
});