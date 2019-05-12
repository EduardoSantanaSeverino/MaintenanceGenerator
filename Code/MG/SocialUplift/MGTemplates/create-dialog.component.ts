import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CampaignServiceProxy,
  CampaignDto,
  PermissionDto,
  CampaignCreateDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-campaign-dialog.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class CreateCampaignDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  campaign: CampaignDto = new CampaignDto();

  constructor(
    injector: Injector,
    private _campaignService: CampaignServiceProxy,
    private _dialogRef: MatDialogRef<CreateCampaignDialogComponent>
  ) {
    super(injector);
  }

  ngOnInit(): void {
	this.campaign.isActive = true;
  }

  save(): void {
    this.saving = true;

    const campaign_ = new CampaignCreateDto();
    campaign_.init(this.campaign);

    this._campaignService
      .create(campaign_)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}
