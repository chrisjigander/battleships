function checkCell(x, y) {

    console.log(x, y);

    window.location.href = "game.aspx?action=CheckCell&x=" + x + "&y=" + y;
}