$(function () {
    $("#confirm-button").on('click', function () {
        SetStatus(1);
    });

    $("#refuse-button").on('click', function () {
        SetStatus(2);
    });

    function SetStatus(status) {
        const id = $("#applicantId").val();
        $("#buttons button").prop('disabled', true);
        $.post("/home/updatestatus", { id, status }, () => {
            $.get("/home/getcounts", counts => {
                $("#pending-count").text(counts.Pending);
                $("#confirmed-count").text(counts.Confirmed);
                $("#refused-count").text(counts.Refused);
                $("#buttons").hide();
            });
        });
    }
});