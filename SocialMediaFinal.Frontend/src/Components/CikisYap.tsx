const CikisYap = () => {
  return (
    <button
      className="bg-red-500 w-64 text-xl p-2 rounded-md cursor-pointer"
      onClick={() => {
        localStorage.removeItem("token");
        window.location.reload();
      }}
    >
      Cikis Yap
    </button>
  );
};

export default CikisYap;
