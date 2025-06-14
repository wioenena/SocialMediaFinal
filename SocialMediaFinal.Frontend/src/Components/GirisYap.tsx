const GirisYap = ({ setAccount }) => {
  const loginOrRegister = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const loginRes = await fetch(
      `${import.meta.env.VITE_API_URL}/auth/account/login`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          username: (event.target as HTMLFormElement).username.value,
          password: (event.target as HTMLFormElement).password.value,
        }),
      }
    );

    if (loginRes.ok) {
      const accountData = await loginRes.json();
      setAccount(accountData);
      localStorage.setItem("token", accountData.accessToken);
      window.location.href = "/";
    } else {
      const errorData = await loginRes.json();
      if (errorData.message === "Account not found") {
        if ((event.target as HTMLFormElement).nameAndSurname.value === "") {
          alert("Lütfen isim ve soyisminizi girin.");
          return;
        }
        const registerRes = await fetch(
          `${import.meta.env.VITE_API_URL}/auth/account/register`,
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              username: (event.target as HTMLFormElement).username.value,
              fullName: (event.target as HTMLFormElement).nameAndSurname.value,
              password: (event.target as HTMLFormElement).password.value,
            }),
          }
        );

        if (registerRes.ok) {
          alert("Kayıt başarılı, giriş yapabilirsiniz.");
          window.location.href = "/";
        }
      } else if (errorData.message.includes("Invalid password")) {
        alert("Şifreniz yanlış, lütfen tekrar deneyin.");
      }
    }

    console.log(loginRes, import.meta);
  };
  return (
    // Make modern and stylish login form
    <div className="flex flex-col items-center justify-center h-full w-full bg-neutral-900 text-white p-6 rounded-lg shadow-lg">
      <h1 className="text-3xl font-bold mb-6 uppercase">
        Giriş Yap veya Kayit Ol
      </h1>
      <form className="w-full max-w-sm" onSubmit={loginOrRegister}>
        <div className="mb-4">
          <input
            type="text"
            id="username"
            className="w-full px-3 py-2 bg-neutral-800 border border-neutral-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Kullanıcı Adı"
            required
          />
        </div>
        <div className="mb-4">
          <input
            type="text"
            id="nameAndSurname"
            className="w-full px-3 py-2 bg-neutral-800 border border-neutral-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Isim Soyisim"
          />
        </div>
        <div className="mb-6">
          <input
            type="password"
            id="password"
            className="w-full px-3 py-2 bg-neutral-800 border border-neutral-700 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Şifrenizi girin"
            required
          />
        </div>
        <button
          type="submit"
          className="w-full cursor-pointer bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:ring-2 focus:ring-blue-500 transition duration-200"
        >
          Giriş Yap veya Kayit Ol
        </button>
      </form>
    </div>
  );
};

export default GirisYap;
