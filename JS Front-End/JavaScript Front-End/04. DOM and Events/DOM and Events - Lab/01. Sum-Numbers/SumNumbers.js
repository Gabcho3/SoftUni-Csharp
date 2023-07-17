function calc() {
  // TODO: sum = num1 + num2
  const num1 = Number(document.getElementById("num1").value);
  const num2 = Number(document.getElementById("num2").value);
  document.querySelector("#sum").value = num1 + num2;
}
