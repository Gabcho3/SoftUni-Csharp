function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const cells = Array.from(document.querySelectorAll("tbody td"));
    const stringToMatch = document.getElementById("searchField").value;

    const selectedRows = [];
    cells.forEach((cell) => {
      if (cell.textContent.toLowerCase().includes(stringToMatch)) {
        selectedRows.push(cell);
      }
      cell.parentElement.classList.remove("select");
    });

    selectedRows.forEach((cell) => {
      cell.parentElement.classList.add("select");
    });

    document.getElementById("searchField").value = "";
  }
}
