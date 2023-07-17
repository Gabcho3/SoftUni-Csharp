function extractText() {
  let textToAdd = "";
  Array.from(document.querySelectorAll("ul li")).forEach(
    (li) => (textToAdd += li.textContent + "\n")
  );
  document.querySelector("#result").textContent = textToAdd;
}
