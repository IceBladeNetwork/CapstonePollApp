let currentChoice = 3;
const newInput = '<div class="form-group">' +
        '<label asp-for="Choices"></label>' + currentChoice.toString +
        '<input class="form-control" asp-for="Choices"/>' +
        '<span asp-validation-for="Choices"></span>' +
    '</div > ';
const add = document.getElementById(`add`);
const div = document.getElementById(`choices`);
add.addEventListener("click", function () {
    div.innerHTML += newInput;
    currentChoice++;
});