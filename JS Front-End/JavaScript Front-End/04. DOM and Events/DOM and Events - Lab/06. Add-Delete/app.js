function addItem() {
  const list = document.getElementById("items");
  const itemToAdd = document.querySelector("#newItemText").value;

  let listItem = document.createElement("li");
  listItem.textContent = itemToAdd;

  let remove = document.createElement("a");
  remove.href = "#";
  remove.textContent = "[Delete]";
  listItem.appendChild(remove);

  remove.addEventListener("click", deleteItem);

  list.appendChild(listItem);
  document.querySelector("#newItemText").value = "";

  function deleteItem() {
    listItem.remove();
  }
}
