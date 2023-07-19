function solve() {
  const words = document.getElementById("text").value.split(" ");
  const convention = document.getElementById("naming-convention").value;
  const result = document.getElementById("result");
  let output = "";

  if (convention != "Pascal Case" && convention != "Camel Case") {
    result.textContent = "Error!";
  } else {
    for (let i = 0; i < words.length; i++) {
      const word = words[i].toLowerCase();
      if (i == 0 && convention === "Camel Case") {
        output += word;
      }

      if (i != 0 || convention === "Pascal Case") {
        output += word[0].toUpperCase() + word.substring(1);
      }
    }
    result.textContent = output;
  }
}
