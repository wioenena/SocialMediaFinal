const PostOlustur = ({ account }) => {
  const createPost = async () => {
    const postContent = prompt("Paylaşımınızı girin:");
    if (!postContent) {
      alert("Lütfen bir paylaşım girin.");
      return;
    }
    try {
      const response = await fetch(
        `${import.meta.env.VITE_API_URL}/auth/posts`,
        {
          method: "POST",
          headers: {
            Authorization: `Bearer ${localStorage.getItem("token")}`,
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ content: postContent }),
        }
      );
      if (!response.ok) {
        throw new Error("Paylaşım oluşturulamadı.");
      }
      const data = await response.json();
      alert("Paylaşımınız başarıyla oluşturuldu!");
      window.location.reload();
    } catch (error) {
      console.error("Error creating post:", error);
      alert("Paylaşım oluşturulurken bir hata oluştu.");
    }
  };
  return (
    <div>
      <button className="bg-green-500 px-4 py-2 rounded" onClick={createPost}>
        Post Olustur
      </button>
    </div>
  );
};

export default PostOlustur;
