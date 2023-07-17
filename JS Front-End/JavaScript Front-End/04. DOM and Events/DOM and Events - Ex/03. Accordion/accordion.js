function toggle() {
  const divToShow = document.querySelector("#extra");
  const moreButton = document.querySelector(".head .button");

  divToShow.style.display =
    divToShow.style.display === "block" ? "none" : "block";
  moreButton.innerText = moreButton.innerText === "More" ? "Less" : "More";
}
