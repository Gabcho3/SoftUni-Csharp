function extract(content) {
  const text = document.getElementById(content).innerText;

  let parenthesizedText = [];
  let startIndex = 0;
  let lastIndex = 0;

  for (let i = 0; i < text.length; i++) {
    const element = text[i];

    if (element === "(") {
      startIndex = i;
    }
    if (element === ")") {
      lastIndex = i;
      parenthesizedText.push(text.substring(startIndex, lastIndex));
    }
  }

  return parenthesizedText.join("; ");
}
