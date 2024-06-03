import { test, expect } from "@playwright/test";

test("user can add a task", async ({ page }) => {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  const taskText = await page.textContent(".task");
  expect(taskText).toContain("Test Task");
});
