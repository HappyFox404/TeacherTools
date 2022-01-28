$(document).ready(function () {
    console.log("Student JS load");

    /*Добавление студента*/

    $('#addStudent').on('click', function () {
        console.log("Open Modal Window Add Student");
    });

    /*Удаление студента*/

    $('#delStudent').on('click', function () {
        $('#fDelStudent').parent().toggleClass("mOn");
    });

    $('#cDelStudent').on('click', function () {
        $('#fDelStudent').parent().toggleClass("mOn");
    })

    /*Добавление группы*/

    $('#addGroup').on('click', function () {
        console.log("Open Modal Window Add Group");
    });

    /*Удаление группы*/

    $('#delGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
    });

    $('#cDelGroup').on('click', function () {
        $('#fDelGroup').parent().toggleClass("mOn");
    })
});