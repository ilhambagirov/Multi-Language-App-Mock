import classes from "../../styles/news.module.css";
import langClasses from "../../styles/lang.module.scss";
import { useState } from "react";
import { useRouter } from "next/router";

export default function NewsList(props) {
  const router = useRouter();
  const [langDropdown, setLangDropdown] = useState(false);
  const [selectedLang, setSelectedLang] = useState({
    label: "az",
  });
  const setLangHandler = () => {
    setLangDropdown(!langDropdown);
  };

  const changeLangHandler = async (lang) => {
    router.push("/news?lang=" + lang.label);
    setSelectedLang(lang);
  };

  const showDetailHandler = (id) => {
    router.push(`/news/${id}?lang=` + router.query.lang);
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
      <ul className={classes["flex"]}>
        {props.news.map((n) => (
          <li className={`${classes.item} col-xl-3 col-lg-4 col-md-6 `}>
            <div className={classes.content}>
              <h3>{n.newsLanguages.title}</h3>
              <p>{n.newsLanguages.context}</p>
            </div>
            <div className={classes.actions}>
              <button onClick={() => showDetailHandler(n.id)} className="me-2">
                Show Details
              </button>
              <button>Delete</button>
            </div>
          </li>
        ))}
      </ul>
    </>
  );
}

export async function getServerSideProps(context) {
  const lang = context.query.lang;
  const settings = {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  };

  const langs = await (
    await fetch(`http://localhost:54902/api/Language`, settings)
  ).json();

  const news = await fetch(`http://localhost:54902/api/News/${lang}`, settings);

  const data = await news.json();
  return {
    props: {
      news: data,
      langs: langs,
    },
  };
}
