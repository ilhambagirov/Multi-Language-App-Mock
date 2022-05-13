import classes from "../../styles/news.module.css";
import langClasses from "../../styles/lang.module.scss";
import { useState } from "react";
import { useRouter } from "next/router";

export default function News(props) {
  const router = useRouter();
  const [langDropdown, setLangDropdown] = useState(false);
  const [selectedLang, setSelectedLang] = useState({
    label: "az",
  });
  const setLangHandler = () => {
    setLangDropdown(!langDropdown);
  };
  const settings = {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  };
  const backHandler = () => {
    router.replace(`/news/?lang=` + selectedLang.label);
  };
  const changeLangHandler = async (lang) => {
    router.push(`/news/${router.query.id}?lang=` + lang.label);
    setSelectedLang(lang);
  };
  return (
    <>
      <ul
        className={`${langClasses["header__multilanguage"]}
            ${langDropdown && langClasses["active"]}`}
        onClick={setLangHandler}
      >
        <li>
          <span>{selectedLang.label}</span>
        </li>
        {props.langs
          .filter((x) => x.label !== selectedLang.label)
          .map((lang) => (
            <li key={lang.label} onClick={() => changeLangHandler(lang)}>
              <span>{lang.label}</span>
            </li>
          ))}
      </ul>
      <ul>
        <li className={`${classes.item} col-xl-3 col-lg-4 col-md-6 `}>
          <div className={classes.content}>
            <h3>{props.news.newsLanguages.title}</h3>
            <p>{props.news.newsLanguages.context}</p>
          </div>
          <div className={classes.actions}>
            <button onClick={backHandler} className="me-2">
              Back
            </button>
            <button>Delete</button>
          </div>
        </li>
      </ul>
    </>
  );
}

export async function getServerSideProps(context) {
  const lang = context.query.lang;
  const id = context.params.id;
  const settings = {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  };
  const news = await fetch(
    `http://localhost:54902/api/News/${id}/${lang}`,
    settings
  );

  const langs = await (
    await fetch(`http://localhost:54902/api/Language`, settings)
  ).json();

  if (news.statusText === "No Content") {
    return {
      notFound: true,
    };
  }
  return {
    props: {
      news: await news.json(),
      langs: langs,
    },
  };
}
