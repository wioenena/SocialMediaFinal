import { useEffect, useState } from "react";
import PostOlustur from "./PostOlustur";
import CikisYap from "./CikisYap";

const Posts = ({ account }: any) => {
  const [posts, setPosts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchPosts = async () => {
      try {
        const response = await fetch(
          `${import.meta.env.VITE_API_URL}/auth/posts`,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("token")}`,
              "Content-Type": "application/json",
            },
          }
        );

        if (!response.ok) {
          throw new Error("Failed to fetch posts");
        }

        const data = await response.json();
        setPosts(data.posts);
      } catch (error) {
        console.error("Error fetching posts:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchPosts();
  }, []);

  const deletePost = async (postId: string) => {
    try {
      const response = await fetch(
        `${import.meta.env.VITE_API_URL}/auth/posts/${postId}`,
        {
          method: "DELETE",
          headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
            "Content-Type": "application/json",
          },
        }
      );
      if (!response.ok) {
        throw new Error("Failed to delete post");
      }
      setPosts((prevPosts) => prevPosts.filter((post) => post.id !== postId));
    } catch (error) {
      console.error("Error deleting post:", error);
    }
  };

  const editPost = async (postId: string) => {
    const newContent = prompt("Yeni paylaşım içeriğini girin:");
    if (!newContent) {
      alert("Lütfen yeni paylaşım içeriğini girin.");
      return;
    }
    try {
      const response = await fetch(
        `${import.meta.env.VITE_API_URL}/auth/posts/`,
        {
          method: "PUT",
          headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ id: postId, content: newContent }),
        }
      );
      if (!response.ok) {
        throw new Error("Failed to update post");
      }
      const updatedPost = await response.json();
      setPosts((prevPosts) =>
        prevPosts.map((post) => (post.id === postId ? updatedPost : post))
      );
      alert("Paylaşım başarıyla güncellendi!");
      window.location.reload();
    } catch (error) {
      console.error("Error updating post:", error);
      alert("Paylaşım güncellenirken bir hata oluştu.");
    }
  };

  if (loading)
    return (
      <div className="h-screen w-screen animate-pulse bg-neutral-800 rounded-lg shadow-lg flex items-center justify-center" />
    );

  if (posts.length === 0 && !loading) {
    return (
      <div className="flex flex-col justify-center items-center h-10/12 w-10/12 gap-y-2">
        <span className="text-white text-xl">Henüz bir paylaşım yok.</span>
        <CikisYap />
        <PostOlustur account={account} />
      </div>
    );
  }

  return (
    <div className="flex flex-col justify-center items-center h-10/12 w-10/12 gap-y-2">
      <CikisYap />
      <PostOlustur account={account} />
      {posts.map((post) => (
        <div
          className="flex flex-col min-w-1/4 bg-neutral-900 text-white p-4 rounded-lg"
          key={post.id}
        >
          <span className="text-blue-500 mb-5">{post.author.fullName}</span>
          <span>{post.content}</span>
          {post.authorId === account.id && (
            <div className="flex justify-between mt-4 gap-x-2 lg:text-xl text-sm px-4 py-2 font-bold">
              <button
                className="w-full bg-red-500 rounded-md p-2 cursor-pointer"
                onClick={() => deletePost(post.id)}
              >
                Sil
              </button>
              <button
                className="w-full bg-gray-500 rounded-md p-2 cursor-pointer"
                onClick={() => editPost(post.id)}
              >
                Duzenle
              </button>
            </div>
          )}
        </div>
      ))}
    </div>
  );
};

export default Posts;
