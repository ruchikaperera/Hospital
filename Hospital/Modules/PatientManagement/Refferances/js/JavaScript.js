function FunForLoginValidation() {
    var objValid = true;
    var objUserName = $("[id$=txtUserName]").val();
    var objPassword = $("[id$=txtPassword]").val();
    if (objUserName == "") {
        $('[id$=lblErrUserName]').text("User Name is required");
        $('[id$=lblErrUserName]').css("color", "#FF0000");
        $("[id$=txtUserName]").addClass("Error-control");
        objValid = false;
    }
    else {
        $('[id$=lblErrUserName]').text("");
        $('[id$=lblErrUserName]').css("color", "#FFFFFF");
        $("[id$=txtUserName]").removeClass("Error-control");
    }

    if (objPassword == "") {
        $('[id$=lblErrPassword]').text("Password is required");
        $('[id$=lblErrPassword]').css("color", "#FF0000");
        $("[id$=txtPassword]").addClass("Error-control");
        objValid = false;
    }
    else {
        $('[id$=lblErrPassword]').text("");
        $('[id$=lblErrPassword]').css("color", "#FFFFFF");
        $("[id$=txtPassword]").removeClass("Error-control");
    }
    return objValid;
}
function AcceptAlphanumeric(evt) {
    var key = evt.keyCode;
    return ((key >= 48 && key <= 57) || (key >= 65 && key <= 90) || (key >= 95 && key <= 122));
}
function NotAllowSingleDoubleQuotes(e) {
    var charCode = e.keyCode;
    if (charCode == 34)
        return false;
    if (charCode == 39)
        return false;
}  