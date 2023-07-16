function addItem() {
  const itemToAdd = document.querySelector("#newItemText").value;

  const newLi = document.createElement("li");
  newLi.textContent = itemToAdd;

  const list = document.getElementById("items");
  list.appendChild(newLi);

  document.querySelector("#newItemText").value = "";
}
