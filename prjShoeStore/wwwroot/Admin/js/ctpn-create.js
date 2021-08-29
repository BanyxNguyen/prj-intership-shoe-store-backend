import SizeProducts from "./size-product.json" assert { type: "json" };
const SanPhamFields = ["TenSanPham", "KichThuoc", "SoLuong", "Gia"];
export default class CTPNCreate {
  constructor({ TableSelector, data, Products, Errors }) {
    const div = document.createElement("div");
    div.innerHTML = data;
    this.Table = document.querySelector("#" + TableSelector);
    this.data = JSON.parse(div.innerText);
    div.innerHTML = Products;
    this.Products = JSON.parse(div.innerText);
    if (Errors) {
      div.innerHTML = Errors;
      this.Errors = JSON.parse(div.innerText);
    }

    this.Initial();
    console.log(SizeProducts);
  }

  getListError = (index) => {
    if (this.Errors?.length > 0) {
      return this.Errors.find((x) => x.Index == index);
    } else {
      return null;
    }
  };

  CreateRow = (item, index) => {
    console.log(item);
    const tr = document.createElement("tr");
    let td = document.createElement("td");
    tr.append(td);

    td.innerText = index + 1;
    SanPhamFields.forEach((field) => {
      td = document.createElement("td");
      tr.append(td);
      if (field == "SoLuong" || field == "Gia") {
        const input = document.createElement("input");
        td.append(input);
        input.type = "number";
        input.value = item[field];
        input.addEventListener("change", (event) => {
          item[field] = input.value;
        });
      } else {
        td.innerText = item[field];
      }
    });
    td = document.createElement("td");
    tr.append(td);
    const btn = document.createElement("button");
    td.append(btn);
    btn.innerHTML = "X";
    btn.className = "btn btn-danger";
    btn.addEventListener("click", (e) =>
      this.onDelete({ event: e, tr, item, index })
    );
    return tr;
  };

  onDelete = ({ event, item, index }) => {
    event.preventDefault();
    console.log(item);
    const indexSP = this.data.findIndex((x) => x.IdSanPham == item.IdSanPham);
    this.data.splice(indexSP, 1);
    this.Render();
  };

  Initial = () => {
    //Initialize Select2 Elements
    const data = this.Products.map((x, index) => ({
      id: index,
      text: x.TenSanPham,
    }));
    console.log(data);
    $(".select2-sp").select2({ data });
    $(".select2-kt").select2({ data: SizeProducts });
    $("#id-ctpn").submit((event) => {});
    $("#btn-add").click(this.onClickAdd);
    $("#btn-submit").click(this.onSubmit);
  };
  onSubmit = () => {
    this.AddDataToForm(document.getElementById("id-ctpn"));
    $("#id-ctpn").submit();
  };
  onClickAdd = () => {
    const value = document.querySelector("#select-sp").value;
    const valueSize = document.querySelector("#select-kt").value;
    if (!value || value < 0) {
      alert("Please choose product!");
      return;
    }
    const product = this.Products[value];

    if (
      this.data.findIndex(
        (x) => x.IdSanPham == product.Id && x.KichThuoc == valueSize
      ) >= 0
    ) {
      alert("the Product is already exist!");
      return;
    }

    this.data.push({
      IdSanPham: product.Id,
      TenSanPham: product.TenSanPham,
      KichThuoc: valueSize,
      SoLuong: 0,
      Gia: 0,
    });
    this.Render();
  };
  AddDataToForm = (form) => {
    const input = form.querySelector(
      "input[name='__RequestVerificationToken']"
    );
    form.innerText = "";
    const temp = "CTPNs";
    this.data.forEach((item, index) => {
      const keys = Object.keys(item);
      keys.forEach((key) => {
        const input = document.createElement("input");
        input.hidden = true;
        input.name = `${temp}[${index}].${key}`;
        input.value = item[key];
        form.append(input);
      });
    });
    form.append(input);
  };
  Render = () => {
    const tbody = this.Table.querySelector("tbody");
    tbody.innerText = "";
    this.data.map((item, index) => {
      const tr = this.CreateRow(item, index);
      tbody.append(tr);
    });

    const trs = tbody.querySelectorAll("tr");
    trs.forEach((tr, index) => {
      const error = this.getListError(index);
      if (error != null) {
        tr.title = error.message.join("\n");
        tr.className = "error-validate";
        console.log(tr);
      }
    });
  };
}
