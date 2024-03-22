<script>
    let info_box;
</script>

<header>
    <div>
        <a href="/"><svg width="327" height="53" viewBox="0 0 327 53" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M0.699696 0.636362H14.3531L28.7736 35.8182H29.3872L43.8077 0.636362H57.4611V53H46.7224V18.9176H46.2878L32.7366 52.7443H25.4241L11.873 18.7898H11.4383V53H0.699696V0.636362ZM65.3585 53V0.636362H100.643V9.7642H76.4295V22.2415H98.8273V31.3693H76.4295V43.8722H100.745V53H65.3585ZM106.226 9.7642V0.636362H149.232V9.7642H133.201V53H122.257V9.7642H106.226ZM157.717 53H145.854L163.93 0.636362H178.197L196.249 53H184.385L171.268 12.6023H170.859L157.717 53ZM156.976 32.4176H184.999V41.0597H156.976V32.4176ZM225.591 22.4972V31.1392H201.711V22.4972H225.591ZM229.679 9.7642V0.636362H272.685V9.7642H256.654V53H245.71V9.7642H229.679ZM288.003 0.636362L300.66 40.4205H301.145L313.827 0.636362H326.1L308.049 53H293.782L275.705 0.636362H288.003Z" fill="black"/></svg></a>
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
        <button on:click={()=>info_box.close()}> X </button>
        <div> 
            some information 
        </div>
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
        margin: 7% auto;
        width: 35%;
        padding: 1%;
        background: white;
        border: none;
    }
    
    .info_box_button {
        position: relative;
        top: -9px;
        left: 5px;
        background: none;
        border: none;
    }

</style>
