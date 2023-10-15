function SubmitCustomerAccount() {
    var CustomerId = $("#CustomerID").val();
    var InitialCredit = $("#InitialCredit").val();

    if (CustomerId == '' || CustomerId == undefined || parseInt(CustomerId) <= 0) {
        $("#errorMessage").text("Invalid Customer ID");
        return;
    }

    if (InitialCredit == '' || InitialCredit == undefined || parseInt(InitialCredit) <= 0) {
        $("#errorMessage").text("Initial Credit Cannot Be In Negative")
        return;

    }

    $.ajax({
        url: "https://localhost:7142/api/Account/CreateAccount",
        type: "POST",
        data: {
            CustomerId: CustomerId,
            InitialCredit: InitialCredit,
        },
        success: function (result) {

        },
        success: function (result) {
            $("#popUp").fadeIn().delay(3000).fadeOut();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status === 404) {
                $("#errorMessage").text("Customer Not Found")
            } else {
                $("#errorMessage").text("Unhandled Error Occured")
            }
        }
    });

}

function ViewCustomerDetails() {
    var CustomerId = $("#DetailsCustomerID").val();
    if (CustomerId == '' || CustomerId == undefined || parseInt(CustomerId) <= 0) {
        $("#errorDetailsMessage").text("Invalid Customer ID");
        return;
    }

    $.ajax({
        url: "https://localhost:7142/api/Customer/GetCustomerInformation",
        type: "Get",
        data: {
            CustomerId: CustomerId,
        },

        success: function (result) {
            $("#Balance").text(result.totalBalance);
            $("#Lname").text(result.lastName);
            $("#Fname").text(result.firstName);

            var tableBody = "";
            var options = { year: 'numeric', month: 'long', day: '2-digit' };
            //const formattedDate = inputDate.toLocaleDateString('en-US', options);
            result.accounts.forEach(function (account) {
                account.transactions.forEach(function (transaction) {
                    console.log(transaction)
                    tableBody += " <tr>"
                    tableBody += "<td>" + transaction.accountId + "</td >";
                    tableBody += "<td>" + transaction.id + "</td >";
                    tableBody += "<td>" + transaction.credit + "</td >";
                    tableBody += "<td>" + new Date(transaction.dateCreated).toLocaleDateString('en-US', { year: 'numeric', month: 'long', day: '2-digit' }); +"</td >";
                    tableBody += " </tr > "

                })

            })
            $("#TableBody").html(tableBody);
            $("#AccountDetails").show();
        },

        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status === 404) {
                $("#errorDetailsMessage").text("Customer Not Found")
            }
            else {
                $("#errorDetailsMessage").text("Unhandled Error Occured")
            }
        }
    });
}