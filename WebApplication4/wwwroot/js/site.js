// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Generate Report
function downloadPdf() {
    const headingDiv = document.createElement('div');
    headingDiv.innerHTML = '<h1>Attendance Report</h1>';
    const tableElement = document.getElementById('table');
    const containerDiv = document.createElement('div');
    containerDiv.appendChild(headingDiv);
    containerDiv.appendChild(tableElement);

    html2pdf(containerDiv, {
        margin: 10,
        filename: 'Attendance Report.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
    });
}
$(document).ready(function () {
    $("#download").click(function () {
        downloadPdf();
    });
});

//Create new attendance
$(document).ready(function () {
    $('#createPartial').submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function (data) {
                if (data.success) {
                    var message = 'Attendance record created successfully!';

                    if (data.countChange !== 1) {
                        message = 'Attendance record created successfully, and the list count is changed!';
                    }
                    Swal.fire({
                        icon: 'success',
                        title: 'Success!',
                        text: message,
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: data.message || 'Check if the Employee Exist or An Attendance Record is Alrteady Made For This Day',
                        confirmButtonText: 'OK'
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error('Error: ', xhr.responseText);
                Swal.fire({
                    icon: 'error',
                    title: 'Error!',
                    text: 'An error occurred while processing the request.',
                    confirmButtonText: 'OK'
                });
            }
        });
    });

    $('#saveButton').click(function () {
        $('#createPartial').submit();
    });
});



//position 
$(document).ready(function () {
    $("#createBtn").click(function (e) {
        e.preventDefault(); 
        var positionValue = $("#position").val();

        var data = {
            Position1: positionValue
        };
        $.ajax({
            url: "/Positions/Create", 
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (response) {
                // Handle the success response, if needed
                // You can update the UI without reloading the page
                // For example, add the new item to the table
                $("table tbody").append("<tr><td>" + response.Position1 + "</td><td><a class='btn btn-secondary' href='#'>Edit</a> | <a class='btn btn-danger' href='#'>Delete</a></td></tr>");

                // Clear the input field
                $("#position").val("");
            },
            error: function (error) {
                // Handle the error, if needed
                console.error(error);
            }
        });
    });
});