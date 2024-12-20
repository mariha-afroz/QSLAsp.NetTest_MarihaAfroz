$(document).on('submit', 'form', function (e) {
    const form = $(this);
    $(':submit', form).attr('disabled', true).text('Processing...');
});