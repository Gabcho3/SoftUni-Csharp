function search() {
  const list = Array.from(document.querySelectorAll("#towns li"));
  const searchedText = document.getElementById("searchText").value;
  list.forEach((element) => {
    const text = element.textContent;

    element.style.textDecoration = text.includes(searchedText)
      ? "underline"
      : "none";
    element.style.fontWeight = text.includes(searchedText) ? "bold" : "normal";
  });

  const matches = list.reduce((acc, curr) => {
    if (curr.style.fontWeight === "bold") {
      acc++;
    }
    return acc;
  }, 0);
  document.getElementById("result").textContent = `${matches} matches found`;
}
