let editedButtonClicked;
async function attachEvents() {
  const loadButton = document.getElementById("loadBooks");
  const submitButton = document.querySelector("#form button");

  loadButton.addEventListener("click", (e) => {
    fetch("http://localhost:3030/jsonstore/collections/books")
      .then((res) => res.json())
      .then((books) => {
        booksList = books;
        loadBooks(books);
      });
  });

  submitButton.addEventListener("click", (e) => {
    if (submitButton.textContent === "Submit") {
      submitBook();
    }
    if (submitButton.textContent === "Save") {
      saveEditedBook(editedButtonClicked);
    }
    document.querySelector("input[name=title]").value = "";
    document.querySelector("input[name=author]").value = "";
  });
}
function loadBooks(books) {
  document.querySelector("tbody").innerHTML = "";

  for (const [id, bookObj] of Object.entries(books)) {
    const tr = document.createElement("tr");
    tr.id = id;

    for (const key of Object.keys(bookObj).reverse()) {
      if (key === "_id") {
        continue;
      }
      const td = document.createElement("td");
      td.textContent = bookObj[key];
      tr.appendChild(td);
    }

    appendRow(tr);
  }
  deleteBook();
  editBook(books);

  function appendRow(tr) {
    const td = document.createElement("td");

    const deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";

    const editButton = document.createElement("button");
    editButton.textContent = "Edit";

    td.appendChild(deleteButton);
    td.appendChild(editButton);
    tr.appendChild(td);

    document.querySelector("tbody").appendChild(tr);
  }
}

function submitBook() {
  const title = document.querySelector("input[name=title]").value;
  const author = document.querySelector("input[name=author]").value;

  if (title && author) {
    const bookObj = {
      author,
      title,
    };

    fetch("http://localhost:3030/jsonstore/collections/books", {
      method: "Post",
      body: JSON.stringify(bookObj),
    });
    fetch("http://localhost:3030/jsonstore/collections/books")
      .then((res) => res.json())
      .then((books) => loadBooks(books));
  }
}
function deleteBook() {
  const deleteButtons = Array.from(
    document.querySelectorAll("tbody button:first-child")
  );

  deleteButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
      const tr = button.parentElement.parentElement;
      const id = tr.id;
      fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: "delete",
      });

      tr.remove();
    });
  });
}
function editBook() {
  const editButtons = Array.from(
    document.querySelectorAll("tbody button:last-child")
  );

  editButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
      document.querySelector("#form h3").textContent = "Edit FORM";
      document.querySelector("#form button").textContent = "Save";
      editedButtonClicked = button;
    });
  });
}
function saveEditedBook(button) {
  document.querySelector("#form h3").textContent = "FORM";
  document.querySelector("#form button").textContent = "Submit";

  const tr = button.parentElement.parentElement;
  const id = tr.id;

  const obj = {
    author: tr.querySelector("td:nth-child(2)").textContent,
    title: tr.querySelector("td:first-child").textContent,
  };
  const title = document.querySelector("input[name=title]").value;
  const author = document.querySelector("input[name=author]").value;

  if (title) {
    tr.querySelector("td:first-child").textContent = title;
    obj.title = title;
  }

  if (author) {
    tr.querySelector("td:nth-child(2)").textContent = author;
    obj.author = author;
  }

  fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
    method: "put",
    body: JSON.stringify(obj),
  });
}
attachEvents();
