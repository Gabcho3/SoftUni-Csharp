function attachEvents() {
  const options = document.getElementById("posts");
  const loadButton = document.getElementById("btnLoadPosts");
  const viewButton = document.getElementById("btnViewPost");

  let posts = [];

  class Post {
    constructor(body, id, title) {
      (this.body = body), (this.id = id), (this.title = title);
    }
  }

  loadButton.addEventListener("click", (e) => {
    options.innerHTML = "";
    addOptions();
  });
  viewButton.addEventListener("click", (e) => {
    document.getElementById("post-comments").innerHTML = "";

    const selectedId = options.value;
    addPostDetails(selectedId);
  });

  function addOptions() {
    fetch("http://localhost:3030/jsonstore/blog/posts")
      .then((res) => res.json())
      .then((res) => {
        for (const postObject of Object.values(res)) {
          const option = document.createElement("option");

          option.value = postObject.id;
          option.innerText = postObject.title.toUpperCase();
          options.appendChild(option);

          const post = new Post(
            postObject.body,
            postObject.id,
            postObject.title
          );
          posts.push(post);
        }
      });
  }

  function addPostDetails(selectedId) {
    fetch("http://localhost:3030/jsonstore/blog/comments")
      .then((res) => res.json())
      .then((comments) => {
        const matchedPost = posts.find((post) => post.id === selectedId);

        document.getElementById("post-title").textContent = matchedPost.title;
        document.getElementById("post-body").textContent = matchedPost.body;

        for (const commentObject of Object.values(comments)) {
          const li = document.createElement("li");
          if (commentObject.postId === selectedId) {
            li.id = selectedId;
            li.textContent = commentObject.text;
            document.getElementById("post-comments").appendChild(li);
          }
        }
      });
  }
}

attachEvents();
