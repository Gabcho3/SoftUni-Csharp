function validate() {
  const input = document.getElementById("email");

  input.addEventListener("mouseout", (e) => {
    const inputText = input.value;
    const regex = /([a-z]+|\d+)(@[a-z]+)([.][a-z]+)/;

    if (!regex.test(inputText)) {
      input.classList.add("error");
    } else {
      input.classList.remove("error");
    }
  });
}
