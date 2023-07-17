function addItem() {
  const textToAdd = document.querySelector("#newItemText").value;
  const valueToAdd = document.querySelector("#newItemValue").value;

  const option = document.createElement("option");
  option.textContent = textToAdd;
  option.value = valueToAdd;

  document.getElementById("menu").appendChild(option);

  document.querySelector("#newItemText").value = "";
  document.querySelector("#newItemValue").value = "";
}
