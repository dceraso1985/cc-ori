import React, { Component } from "react";
import { RouteComponentProps } from "react-router-dom";
import { getButtonClickLog, updateButtonClickLog } from '../../apis/messageListApi';
import { WithTranslation } from "react-i18next";
import { TFunction } from "i18next";

export interface CountButtonClickProps extends RouteComponentProps, WithTranslation {
}

export interface IButtonClickLog {
  PartitionKey: string;
  RowKey: string;
  ButtonLink: string;
  Timestamp: Date;
}

export class CountButtonClick extends React.Component<CountButtonClickProps> {

  readonly localize: TFunction;
  public btnClickLog: any;

  constructor( props: CountButtonClickProps ){
    super(props);
    this.state = { ...props };
    this.localize = this.props.t;


  }

  componentWillMount() {

    const pk: string = '';
    const rk: string = '';

    // Get Button Click Log Data
    const buttonLink = this.getBtnClickLog(pk, rk);

    // Update Timestamp of Button Click Log Data
    this.countBtnClick();

    // Redirecting to real url
    window.open(buttonLink.toString(), "_blank");
  }

  private getBtnClickLog = async (pk: string, rk: string) => {
    try {

      await getButtonClickLog(pk, rk).then(res => {
        this.btnClickLog = res.data;
        return res.data.ButtonLink;
      });

    } catch (error) {
        return error;
    }
  }

  private countBtnClick = async () => {
    try {

      updateButtonClickLog(this.btnClickLog).then(res => {
        return ;
      });

    } catch (error) {
        return error;
    }
  }

  render(){
    return (<section>Redirecting...</section>);
  }
}

export default CountButtonClick;