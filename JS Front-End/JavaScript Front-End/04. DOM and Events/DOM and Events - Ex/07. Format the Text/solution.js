function solve() {
  let texts = document.getElementById("input").value.split(".");
  texts = texts.filter((text) => text.length > 0);

  let textToAdd = [];
  for (let i = 1; i <= texts.length; i++) {
    textToAdd.push(texts[i - 1]);

    if (i % 3 === 0) {
      appendParagraph(textToAdd);
      textToAdd = [];
    }
  }

  if (textToAdd.length > 0 && textToAdd.length < 3) {
    appendParagraph(textToAdd);
  }

  function appendParagraph(textToAdd) {
    const paragraph = document.createElement("p");
    paragraph.textContent = textToAdd.join(".") + ".";
    document.getElementById("output").appendChild(paragraph);
  }
}
