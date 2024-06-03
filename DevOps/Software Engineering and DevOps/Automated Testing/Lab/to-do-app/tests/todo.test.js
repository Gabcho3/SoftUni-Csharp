import { test, expect } from "@playwright/test";

//Verify if user can add a task
test("user can add a task", async ({ page }) => {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  const taskText = await page.textContent(".task");
  expect(taskText).toContain("Test Task");
});

//Verify if user can delete a task
test("user can delete a task", async ({ page }) => {
  //Add a task
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  //Delete the task
  await page.click(".delete-task");

  const tasks = await page.$$eval(".task", (tasks) =>
    tasks.map((task) => task.textContent)
  );

  expect(tasks).not.toContain("Test Task");
});
