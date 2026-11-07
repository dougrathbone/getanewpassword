$("#submitButton").on("click", function (e) {
    e.preventDefault();
    $.ajax({
        type: "GET",
        url: "/api/generatepassword",
        data: { }
    }).done(function (msg) {
        $("#result").html(msg.Password);
    });
});