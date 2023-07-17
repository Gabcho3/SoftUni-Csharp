function sumTable() {
  const prices = Array.from(
    document.querySelectorAll("td:nth-child(even):not(#sum)")
  );
  const sum = prices.reduce((acc, curr) => {
    return acc + Number(curr.innerText);
  }, 0);

  document.getElementById("sum").innerText = sum;
}
