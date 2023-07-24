function attachEvents() {
  const loadButton = document.getElementById("btnLoad");
  const createButton = document.getElementById("btnCreate");

  loadButton.addEventListener("click", load);

  createButton.addEventListener("click", (e) => {
    const person = document.getElementById("person").value;
    const phone = document.getElementById("phone").value;

    if (!person || !phone) {
      return;
    }

    const obj = {
      person,
      phone,
    };

    fetch("http://localhost:3030/jsonstore/phonebook", {
      method: "post",
      body: JSON.stringify(obj),
    });

    load();
  });
}
function load() {
  document.getElementById("person").value = "";
  document.getElementById("phone").value = "";
  document.getElementById("phonebook").innerHTML = "";

  fetch("http://localhost:3030/jsonstore/phonebook")
    .then((res) => res.json())
    .then((phones) => {
      addListItems(phones);
    });
}
function addListItems(phones) {
  for (const [key, obj] of Object.entries(phones)) {
    const li = document.createElement("li");
    li.id = "phonebook";
    li.textContent = `${obj.person}: ${obj.phone}`;

    const deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";

    li.appendChild(deleteButton);
    document.getElementById("phonebook").appendChild(li);

    deletePhone(key);
  }
}
function deletePhone(key) {
  const deleteButtons = Array.from(document.querySelectorAll("li button"));
  deleteButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
      fetch(`http://localhost:3030/jsonstore/phonebook/${key}`, {
        method: "delete",
      });
      button.parentElement.remove();
    });
  });
}
attachEvents();
