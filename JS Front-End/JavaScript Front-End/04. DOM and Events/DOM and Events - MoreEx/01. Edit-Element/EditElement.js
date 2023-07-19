function editElement(htmlElement, stringMatch, replacer) {
  let text = htmlElement.textContent;

  while (text.includes(stringMatch)) {
    text = text.replace(stringMatch, replacer);
  }
  htmlElement.textContent = text;
}
