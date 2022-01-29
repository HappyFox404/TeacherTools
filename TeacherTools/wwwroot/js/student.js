$(document).ready(function () {
    console.log("Student JS load");

    /*Удаление студента*/

    $('#delStudent').on('click', function () {
        $('#fDelStudent').parent().toggleClass("mOn");
    });

    $('#cDelStudent').on('click', function () {
        $('#fDelStudent').parent().toggleClass("mOn");
    });

    /*Удаление группы*/

    $('#delGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
    });

    $('#cDelGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
    });
});