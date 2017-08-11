// variables
var modal = document.getElementById('myModal');

// var audio = new Audio('./Content/bf3.mp3');

var btn = document.getElementById("myBtn");
var span = document.getElementsByClassName("close")[0];

function checkCell(x, y) {
    window.location.href = "game.aspx?action=CheckCell&x=" + x + "&y=" + y;
}

function displayHighscore(highScore) {
    $("#scoreText").html(`WAR IS OVER. YOUR SCORE WAS ${highScore}`);
    modal.style.display = "block";
    audio.pause();
}

function displayModalBox() {
    modal.style.display = "block";
}


// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
}