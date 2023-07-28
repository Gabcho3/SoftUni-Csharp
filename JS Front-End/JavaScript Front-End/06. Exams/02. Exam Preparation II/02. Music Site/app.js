window.addEventListener("load", solve);

function solve() {
  const addButton = document.getElementById("add-btn");
  let currLikes = 0;

  addButton.addEventListener("click", (e) => {
    const Genre = document.getElementById("genre").value;
    const Name = document.getElementById("name").value;
    const Author = document.getElementById("author").value;
    const Date = document.getElementById("date").value;

    if (
      /\S+/.test(Genre) &&
      /\S+/.test(Name) &&
      /\S+/.test(Author) &&
      /\S+/.test(Date)
    ) {
      const song = {
        Genre,
        Name,
        Author,
        Date,
      };
      addSong(song);
      clearFields();
      catchSongsButtonEvents();
    }
  });

  function addSong(song) {
    const div = document.createElement("div");
    div.classList.add("hits-info");
    const img = document.createElement("img");
    img.src = "./static/img/img.png";
    div.appendChild(img);

    let heading;
    for (const [key, value] of Object.entries(song)) {
      if (key === "Date") {
        heading = document.createElement("h3");
      } else {
        heading = document.createElement("h2");
      }

      heading.textContent = `${key}: ${value}`;
      div.appendChild(heading);
    }

    const buttonsContent = ["Save song", "Like song", "Delete"];
    const buttonsClass = ["save-btn", "like-btn", "delete-btn"];

    for (let i = 0; i < buttonsContent.length; i++) {
      const button = document.createElement("button");
      button.classList.add(buttonsClass[i]);
      button.textContent = buttonsContent[i];

      div.appendChild(button);
    }

    document.querySelector(".all-hits-container").appendChild(div);
  }
  function clearFields() {
    Array.from(document.querySelectorAll(".first-container input")).forEach(
      (field) => {
        field.value = "";
      }
    );
  }
  function catchSongsButtonEvents() {
    Array.from(document.getElementsByClassName("like-btn")).forEach(
      (button) => {
        button.addEventListener("click", (e) => {
          document.querySelector(
            ".likes p"
          ).textContent = `Total Likes: ${++currLikes}`;
          button.disabled = true;
        });
      }
    );

    Array.from(document.getElementsByClassName("save-btn")).forEach(
      (button) => {
        button.addEventListener("click", (e) => {
          addSongToSaved(button);
        });
      }
    );

    Array.from(document.getElementsByClassName("delete-btn")).forEach(
      (button) => {
        button.addEventListener("click", (e) => {
          button.parentElement.remove();
        });
      }
    );
  }
  function addSongToSaved(button) {
    const divToMove = button.parentElement;
    divToMove.remove();

    divToMove.querySelector(".save-btn").remove();
    divToMove.querySelector(".like-btn").remove();
    document.querySelector(".saved-container").appendChild(divToMove);
  }
}
