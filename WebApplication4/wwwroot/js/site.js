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
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: 'Error creating attendance record.',
                        confirmButtonText: 'OK'
                    });
                } else {             
                    Swal.fire({
                        icon: 'success',
                        title: 'Success!',
                        text: 'Attendance record created successfully!',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                }
            },
            error: function (xhr, status, error) {
                alert('Error: ' + xhr.responseText); // Alert the error details
            }
        });
    });

    $('#saveButton').click(function () {
        $('#createPartial').submit();
    });
});
