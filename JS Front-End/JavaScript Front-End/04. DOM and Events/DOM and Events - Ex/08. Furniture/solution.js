function solve() {
  const allButtons = Array.from(document.querySelectorAll("button"));
  const generateButton = allButtons.find(
    (button) => button.textContent === "Generate"
  );
  const buyButton = allButtons.find((button) => button.textContent === "Buy");

  generateButton.addEventListener("click", generateFurniture);
  buyButton.addEventListener("click", buy);
}
function generateFurniture() {
  const areaValue = document.querySelector("textarea").value;
  arrayOfObjects = JSON.parse(areaValue);

  for (const furniture of arrayOfObjects) {
    const newRow = document.createElement("tr");
    for (const [key, value] of Object.entries(furniture)) {
      const newCell = document.createElement("td");

      if (key === "img") {
        const newImg = document.createElement("img");
        newImg.src = value;
        appendNewChild(newCell, newImg);
      } else {
        const newP = document.createElement("p");
        newP.textContent = value;
        newCell.id = key;

        appendNewChild(newCell, newP);
      }

      appendNewChild(newRow, newCell);
    }
    const newCell = document.createElement("td");
    const newCheckBox = document.createElement("input");
    newCheckBox.type = "checkbox";
    appendNewChild(newCell, newCheckBox);
    appendNewChild(newRow, newCell);
    appendNewChild(document.querySelector(".table tbody"), newRow);
  }
}
function appendNewChild(element, child) {
  element.appendChild(child);
}
function buy() {
  const allCheckBoxes = Array.from(
    document.querySelectorAll("input[type=checkbox]")
  ).filter((checkBox) => checkBox.checked);

  let boughtFurnitures = [];
  let totalPrice = 0;
  let averageDecorationFactor = 0;

  allCheckBoxes.forEach((checkBox) => {
    const row = checkBox.parentElement.parentElement;
    const name = row.querySelector("#name").textContent;
    const price = Number(row.querySelector("#price").textContent);
    const decorationFactor = Number(
      row.querySelector("#decFactor").textContent
    );

    boughtFurnitures.push(name);
    totalPrice += price;
    averageDecorationFactor += decorationFactor;
  });
  averageDecorationFactor /= allCheckBoxes.length;
  printOutput(boughtFurnitures, totalPrice, averageDecorationFactor);
}
function printOutput(boughtFurnitures, totalPrice, averageDecorationFactor) {
  const output = [];
  output.push(`Bought furniture: ${boughtFurnitures.join(", ")}`);
  output.push(`Total price: ${totalPrice.toFixed(2)}`);
  output.push(`Average decoration factor: ${averageDecorationFactor}`);
  Array.from(document.querySelectorAll("#exercise textArea"))[1].value =
    output.join("\n");
}
