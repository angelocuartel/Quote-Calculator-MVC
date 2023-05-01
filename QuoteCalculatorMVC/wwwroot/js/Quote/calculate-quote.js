var quoteInformationObj = {};
var totalPayment = {};

const quoteCalculatePartialHtml = $('#quote-calculate');
const quoteConfirmationPartialHtml = $("#quote-confirmation");
const currencyFormatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD'
});


$('#range-month-input').on('input', function () {
    $('#term-counter').html($(this).val() + ' Months');
});

$('#range-amount-input').on('input', function () {
    $('#amount').html(currencyFormatter.format($(this).val()));
});


$('.calculate-quote-btn').on('click', function () {
    quoteInformationObj = JSON.parse(JSON.stringify($('#form-group').serializeArray()));
    console.log(quoteInformationObj);
    quoteCalculatePartialHtml.attr('hidden', true);
    quoteConfirmationPartialHtml.removeAttr('hidden');

    $('#finance-section').removeAttr('hidden');
    $('#details-section').removeAttr('hidden');

    const principal = parseFloat(quoteInformationObj[2].value);
    const monthsToPay = parseInt(quoteInformationObj[1].value);

    computeWeeklyPayment(principal, monthsToPay);

    setQuoteInformation();
});


$('.save-quote').on('click', function () {
    saveQuote();
});


const updateSection = (sectionTobeHide) => {
    quoteCalculatePartialHtml.removeAttr('hidden');
    quoteConfirmationPartialHtml.attr('hidden',true);
    $('#' + sectionTobeHide + '-section').attr('hidden',true);
};


const setQuoteInformation = () => {
    $('#fullname').html(quoteInformationObj[5].value + ', ' + quoteInformationObj[4].value);
    $('#email').html(quoteInformationObj[7].value);
    $('#mobile').html(quoteInformationObj[8].value);
    $('#term').html(quoteInformationObj[1].value);
    $('#finance-amount').html(currencyFormatter.format(quoteInformationObj[2].value));
}


const computeWeeklyPayment = (principal,monthlyPayment) => {
    $.ajax({
        type: 'GET',
        url: '/Quote/GetTotalPayment?principal='+principal+'&monthsToPay='+monthlyPayment,
        success: (result) => {
            totalPayment = result;
            $('#weekly-payment').html(currencyFormatter.format(result.monthlyPayments));
            $('#establishment-fee').html(currencyFormatter.format(result.establishmentFee));
            $('#interest-fee').html(currencyFormatter.format(result.interestFee));
            $('#total-repayment-fee').html(currencyFormatter.format(result.totalRepayments));
        }
    });
}

const saveQuote = () => {

    const dto = {
        QuoteInformation: {
            Id:parseInt(quoteInformationObj[0].value),
            AmountRequired: parseFloat(quoteInformationObj[2].value),
            Term: parseInt(quoteInformationObj[1].value),
            FirstName: quoteInformationObj[4].value,
            LastName: quoteInformationObj[5].value,
            DateOfBirth: quoteInformationObj[6].value,
            MobileNo: quoteInformationObj[8].value,
            Email: quoteInformationObj[7].value,
            Title: quoteInformationObj[3].value,
            },
        quotePayment:totalPayment
    };


    $.ajax({
        type: 'POST',
        url: '/Quote/Save',
        contentType: 'application/json;charset=utf-8',
        traditional:true,
        data: JSON.stringify(dto),
        beforeSend: () => {
            swal.fire({
                title: "Processing..",
                text: 'This may take a for while, please wait...',
                timerProgressBar: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                showCloseButton: false,
                showConfirmButton: false,
                didOpen: () => swal.showLoading()
            });
        },
        success: () => {
            window.location.href = '/Quote/Success';
        },
        error: (err) => {
            console.log(err);
            Swal.fire({
                title: 'Error',
                text: err.responseText,
                icon:'error'
            });
        }
    });
}




