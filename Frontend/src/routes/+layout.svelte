<script>
    let instructions = load_instructions();
    let info_box;

    async function load_instructions() {
        const response = await fetch('instructions.txt');
        const text = await response.text();

        return text;
    }

</script>

<header>
    <div>
        <a href="/"><h1>META-TV</h1></a>
        <button class="info_box_button" on:click={()=>info_box.showModal()}><svg xmlns="http://www.w3.org/2000/svg" width="2.5em" height="2.5em" viewBox="0 0 48 48" fill="black" fill-rule="evenodd" ><path d="M23.8505 0C10.6792 0 0 10.683 0 23.8505C0 37.0258 10.6792 47.7011 23.8505 47.7011C37.0219 47.7011 47.7011 37.0258 47.7011 23.8505C47.7011 10.683 37.0219 0 23.8505 0ZM23.8505 43.0849C13.2205 43.0849 4.61624 34.4841 4.61624 23.8505C4.61624 13.2241 13.2209 4.61624 23.8505 4.61624C34.4766 4.61624 43.0849 13.2208 43.0849 23.8505C43.0849 34.4804 34.4841 43.0849 23.8505 43.0849ZM34.1644 18.5419C34.1644 24.9904 27.1995 25.0896 27.1995 27.4727V28.0821C27.1995 28.7194 26.6828 29.2362 26.0455 29.2362H21.6555C21.0182 29.2362 20.5015 28.7194 20.5015 28.0821V27.2493C20.5015 23.8117 23.1077 22.4375 25.0772 21.3333C26.7661 20.3864 27.8012 19.7425 27.8012 18.4886C27.8012 16.83 25.6855 15.7291 23.9751 15.7291C21.745 15.7291 20.7155 16.7848 19.2683 18.6113C18.8781 19.1037 18.1661 19.1952 17.6655 18.8156L14.9896 16.7866C14.4984 16.4142 14.3884 15.7223 14.7353 15.2129C17.0076 11.8763 19.9017 10.0018 24.4078 10.0018C29.127 10.0018 34.1644 13.6856 34.1644 18.5419ZM27.8898 34.6218C27.8898 36.849 26.0778 38.661 23.8505 38.661C21.6233 38.661 19.8113 36.849 19.8113 34.6218C19.8113 32.3945 21.6233 30.5826 23.8505 30.5826C26.0778 30.5826 27.8898 32.3945 27.8898 34.6218Z" clip-rule="evenodd"/></svg></button>
    </div>
    <nav>
        <a href="/history"><svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 16 16"><path fill="black" fill-rule="evenodd" d="M4.806.665A8 8 0 1 1 .612 11.07a.75.75 0 1 1 1.385-.575A6.5 6.5 0 1 0 2.523 4.5H4.25a.75.75 0 0 1 0 1.5H0V1.75a.75.75 0 0 1 1.5 0v1.586A8 8 0 0 1 4.806.666ZM8 3a.75.75 0 0 1 .75.75v3.94l2.034 2.034a.75.75 0 1 1-1.06 1.06L7.47 8.53l-.22-.22V3.75A.75.75 0 0 1 8 3" clip-rule="evenodd"/></svg></a>
        <a href="/restore" class="nav-button">Restore slides</a>
        <a href="/login" class="nav-button">Log in</a>
    </nav>
</header>

<main>
    <dialog class="info_box" bind:this={info_box}>
        {#await instructions}
            wating...
        {:then instructions}
            {@html instructions}
        {/await}
        <button class="info_box_exit" on:click={()=>info_box.close()}> X </button>
    </dialog>
    <slot />
</main>
<footer>
    <p>
        Created with passion by Avid, Benjamin, Daniel N, Daniel S,<br/>
        Dennis, Jacob, Jonathan & Ossian in PVK 2024
    </p>
</footer>

<style>
    header {
        padding: 0.2em 2em;
        box-shadow: 0 0 1em #111;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }

    nav {
        display: flex;
        align-items: center;
    }

    nav > * {
        margin: 0.5em 1em;
    }

    header a {
        text-decoration: none;
        color: black;
        display: inline-block;
    }

    .nav-button {
        padding: 0.8em 1em;
        color: white;
        background-color: #e83c84;
        border-radius: 0.5em;
    }

    footer {
        background-color: #eeeeee;
        padding: 3em 0;
    }

    footer p {
        text-align: center;
    }

    .info_box::backdrop {
        background: #00000080;
    }

    .info_box {
        border-radius: 10px;
        margin: 5% auto;
        width: 35%;
        padding: 15px;
        background: white;
        border: none;
    }
    
    .info_box_button {
        position: relative;
        top: 7px;
        left: 6px;
        background: none;
        border: none;
    }

    .info_box_exit {
        font-weight: bold;
        position: absolute;
        border: none;
        background: none;
        top: 7%;
        left: 95%;
    }

</style>
