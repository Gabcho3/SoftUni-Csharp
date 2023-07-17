function create(words) {
  const paragraphsToAdd = words.map((word) => {
    const paragraph = document.createElement("p");
    paragraph.style.display = "none";
    paragraph.innerText = word;
    return paragraph;
  });

  paragraphsToAdd.forEach((paragraph) => {
    const div = document.createElement("div");

    div.appendChild(paragraph);

    div.addEventListener("click", (e) => {
      paragraph.style.display = "block";
    });

    document.getElementById("content").appendChild(div);
  });
}
