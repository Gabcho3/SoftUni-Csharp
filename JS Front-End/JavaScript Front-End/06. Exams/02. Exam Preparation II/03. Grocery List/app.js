window.addEventListener("onload", attachEvents);
function attachEvents() {
  const addButton = document.getElementById("add-product");
  const loadButton = document.getElementById("load-product");

  loadButton.addEventListener("click", loadProducts);
  addButton.addEventListener("click", addProduct);
}
async function loadProducts() {
  document.getElementById("tbody").innerHTML = "";

  const products = await (
    await fetch("http://localhost:3030/jsonstore/grocery/")
  ).json();

  for (const productObj of Object.values(products)) {
    const tr = document.createElement("tr");
    for (const [key, value] of Object.entries(productObj)) {
      const td = document.createElement("td");
      if (key === "product") {
        td.classList.add("name");
      } else if (key === "count") {
        td.classList.add("count-product");
      } else if (key === "price") {
        td.classList.add("product-price");
      } else if (key === "_id") {
        tr.id = value;
        continue;
      }
      td.textContent = value;
      tr.appendChild(td);
    }
    const tdButton = document.createElement("td");
    tdButton.classList.add("btn");

    const buttonsContent = ["Update", "Delete"];
    const buttonsClass = ["update", "delete"];

    for (let i = 0; i < buttonsContent.length; i++) {
      const btn = document.createElement("button");
      btn.textContent = buttonsContent[i];
      btn.classList.add(buttonsClass[i]);
      tdButton.appendChild(btn);
    }
    tr.appendChild(tdButton);
    document.getElementById("tbody").appendChild(tr);
  }

  catchProductButtonsEvents();
}
function addProduct() {
  const product = document.getElementById("product").value;
  const count = document.getElementById("count").value;
  const price = document.getElementById("price").value;

  fetch("http://localhost:3030/jsonstore/grocery/", {
    method: "post",
    body: JSON.stringify({ product, count, price }),
  });
  emptyFields();
  loadProducts();
}
function emptyFields() {
  document
    .querySelectorAll("#signup input")
    .forEach((field) => (field.value = ""));
}
function catchProductButtonsEvents() {
  Array.from(document.querySelectorAll(".delete")).forEach((button) => {
    button.addEventListener("click", (e) => {
      const id = button.parentElement.parentElement.id;
      fetch(`http://localhost:3030/jsonstore/grocery/${id}`, {
        method: "delete",
      });
      document.getElementById("add-product").disabled = false;
      loadProducts();
    });
  });

  Array.from(document.querySelectorAll(".update")).forEach((button) => {
    button.addEventListener("click", (e) => {
      document.getElementById("add-product").disabled = true;
      const updateButton = document.getElementById("update-product");
      const tr = button.parentElement.parentElement;
      updateButton.disabled = false;

      document.getElementById("product").value =
        tr.querySelector(".name").textContent;
      document.getElementById("count").value =
        tr.querySelector(".count-product").textContent;
      document.getElementById("price").value =
        tr.querySelector(".product-price").textContent;

      updateButton.addEventListener("click", (e) => {
        document.getElementById("add-product").disabled = false;
        updateButton.disabled = true;

        const id = tr.id;
        const product = document.getElementById("product").value;
        const count = document.getElementById("count").value;
        const price = document.getElementById("price").value;

        if ((product, count, price)) {
          fetch(`http://localhost:3030/jsonstore/grocery/${id}`, {
            method: "put",
            body: JSON.stringify({ product, count, price, _id: id }),
          });
          emptyFields();
          loadProducts();
        }
      });
    });
  });
}
attachEvents();
