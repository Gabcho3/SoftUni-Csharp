function solution() {
  fetch("http://localhost:3030/jsonstore/advanced/articles/list")
    .then((res) => res.json())
    .then((articles) => {
      for (let i = 0; i < articles.length; i++) {
        const articleObj = articles[i];

        const div = document.createElement("div");
        div.classList.add("accordion");
        div.innerHTML = `
            <div class="head">
                <span>${articleObj.title}</span>
                <button class="button" id="${articleObj["_id"]}">More</button>
            </div>
            <div class="extra">
                <p></p>
            </div>
        </div>`;

        document.getElementById("main").appendChild(div);
      }

      const moreButtons = Array.from(document.getElementsByClassName("button"));

      moreButtons.forEach((button) => {
        const divToShow =
          button.parentElement.parentElement.querySelector(".extra");

        button.addEventListener("click", (e) => {
          fetch(
            `http://localhost:3030/jsonstore/advanced/articles/details/${button.id} `
          )
            .then((res) => res.json())
            .then((article) => {
              divToShow.querySelector("p").textContent = article.content;
              button.textContent =
                button.textContent === "More" ? "Less" : "More";
              divToShow.style.display =
                divToShow.style.display === "block" ? "none" : "block";
            });
        });
      });
    });
}
