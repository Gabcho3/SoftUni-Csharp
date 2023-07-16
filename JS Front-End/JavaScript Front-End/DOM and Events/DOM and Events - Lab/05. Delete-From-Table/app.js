function deleteByEmail() {
  let emails = Array.from(
    document.querySelectorAll("tbody tr td:nth-child(even)")
  );
  const emailToMatch = document.querySelector("input[type=text]").value;

  const elementToRemove = emails.find(
    (email) => email.innerText === emailToMatch
  );

  if (elementToRemove) {
    elementToRemove.parentElement.remove();
    document.getElementById("result").textContent = "Deleted";
  } else {
    document.getElementById("result").textContent = "Not found.";
  }
}
