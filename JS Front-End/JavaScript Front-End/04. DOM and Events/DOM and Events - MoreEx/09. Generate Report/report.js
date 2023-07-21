function generateReport() {
  const checkedCells = Array.from(
    document.querySelectorAll("input[type=checkbox]")
  ).filter((checkbox) => checkbox.checked);

  let allCellsText = [];
  checkedCells.forEach((input) => {
    switch (input.name) {
      case "employee": allCellsText.push(getAllCells(1)); break;
      case "deparment": allCellsText.push(getAllCells(2)); break;
      case "status": allCellsText.push(getAllCells(3)); break;
      case "dateHired": allCellsText.push(getAllCells(4)); break;
      case "benefits": allCellsText.push(getAllCells(5)); break;
      case "salary": allCellsText.push(getAllCells(6)); break;
      case "rating": allCellsText.push(getAllCells(7)); break;
    }
  });

  let arrayOfObjects = createAndAddObjects(allCellsText, checkedCells);

  document.getElementById("output").value = JSON.stringify(arrayOfObjects);
}

function getAllCells(nthChild) {
  return Array.from(document.querySelectorAll(`td:nth-child(${nthChild})`)).map(
    (cell) => cell.textContent
  );
}

function createAndAddObjects(allCellsText, checkedCells) {
  let arrayOfObjects = [];
  for (let i = 0; i < allCellsText[0].length; i++) {
    const obj = {};
    let index = 0;

    for (const key of checkedCells.map((cell) => cell.name)) {
      let value = allCellsText[index++][i];

      if (/^\d+$/.test(value)) {
        value = Number(value);
      }
      obj[key] = value;
    }
    arrayOfObjects.push(obj);
  }

  return arrayOfObjects;
}
