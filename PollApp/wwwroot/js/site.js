var currentChoice = 2;
var newInput = '<div class="form-group"><label>Choice {1}</label><input class="form-control" name="Choices[{0}]"/><span asp-validation-for="Choice"></span></div > ';
$("#add").click(function() {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) {
            $("#choices").append(newInput.replace("{0}", currentChoice - 1).replace("{1}", currentChoice));
        }
    });
    currentChoice++;
    return false;
});