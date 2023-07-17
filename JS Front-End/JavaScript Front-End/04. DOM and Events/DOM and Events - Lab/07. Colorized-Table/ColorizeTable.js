function colorize() {
  const cellsToColorize = Array.from(
    document.querySelectorAll("tr:nth-child(even)")
  );
  cellsToColorize.forEach((cell) => (cell.style.backgroundColor = "Teal"));
}
